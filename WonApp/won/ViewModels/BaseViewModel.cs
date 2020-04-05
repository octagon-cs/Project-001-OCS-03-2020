using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

using Xamarin.Forms;

using won.Models;
using won.Services;
using Newtonsoft.Json;
using won.Models.Accounts;
using System.Collections.ObjectModel;
using System.Linq;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;

namespace won.ViewModels
{

    public delegate void ExecuteEvent(string ev, object data);
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event ExecuteEvent OnExecute;


        public void Execute(string ev, object data)
        {
            OnExecute?.Invoke(ev, data);
        }

        public IAccountService AccountService => DependencyService.Get<IAccountService>();
        public IPermohonanService<PermohonanModel> PermohonanService => DependencyService.Get<IPermohonanService<PermohonanModel>>();
        public IJenisPermohonanService<JenisPermohonanModel> JenisPermohonan => DependencyService.Get<IJenisPermohonanService<JenisPermohonanModel>>();
        public IPejabatService<PejabatModel> Pejabat => DependencyService.Get<IPejabatService<PejabatModel>>();
        public IDocumentService DocumentPenduduk => DependencyService.Get<IDocumentService>();

        bool isBusy = false;
        public bool IsBusy
        {
            get { return isBusy; }
            set { SetProperty(ref isBusy, value); }
        }

        string title = string.Empty;
        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }

        protected bool SetProperty<T>(ref T backingStore, T value,
            [CallerMemberName]string propertyName = "",
            Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }


    public class BaseViewModelSurat<T> : BaseViewModel
    {
        public T Model { get; set; } = (T)Activator.CreateInstance(typeof(T));
        public PermohonanModel Permohonan { get; set; }

        public List<Penduduk> Anggotakeluarga { get; set; }


        public ObservableCollection<DocumentPenduduk> Persyaratan { get; set; } = new ObservableCollection<DocumentPenduduk>();

        public virtual void SetValue(PermohonanModel model) { }

        public async Task Load()
        {
            var model = Model as BaseNotify;
            model.NIK = Helper.Profile.nik;
            model.PropertyChanged += Model_PropertyChanged;


            Anggotakeluarga = await AccountService.GetAnggotakeluarga(); ;

            if (Permohonan != null)
            {
                var _Persyaratan = await DocumentPenduduk.GetDocumentByPermohonanId(Permohonan.IdPermohonan);
                foreach (var item in _Persyaratan)
                {
                    Persyaratan.Add(item);
                }
            }
            else
            {
                var jenisPermohonan = await JenisPermohonan.Get();
                var jenis = jenisPermohonan.Where(x => x.JenisPermohonan == PermohonanType.Pindah).FirstOrDefault();

                foreach (var item in jenis.Persyaratan)
                {
                    var data = new Models.DocumentPenduduk
                    {
                        idpersyaratan = item.IdDetailPersyaratan,
                        idpenduduk = Helper.Profile.idpenduduk,
                        nama = item.Nama
                    };

                    if (item.Status == 0)
                        data.idpermohonan = Permohonan.IdPermohonan;

                    Persyaratan.Add(data);
                }
            }

            SaveCommand = new Command(SaveAction);
        }

        private void Model_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            var model = Model as BaseNotify;
            if (model.Valid)
                SaveCommand = new Command(SaveAction, x => model.Valid);
        }

        private async void SaveAction(object obj)
        {
            try
            {

                if (IsBusy)
                    return;

                IsBusy = true;


                if (Permohonan == null)
                {
                    var jenisPermohonan = await JenisPermohonan.Get();
                    var jenis = jenisPermohonan.Where(x => x.JenisPermohonan == PermohonanType.Pindah).FirstOrDefault();
                    var lurah = await Pejabat.GetLurah();
                    if (jenis != null)
                    {
                        var idpenduduk = Helper.Profile.idpenduduk;
                        Permohonan = new PermohonanModel()
                        {
                            IdPejabat = lurah.IdPejabat,
                            IdPenduduk = Convert.ToInt32(idpenduduk),
                            IdJenisPermohonan = jenis.IdJenisPermohonan,
                            TanggalPengajuan = DateTime.Now,
                            Data = JObject.FromObject(Model),
                            Status = StatusPersetujuan.Baru
                        };
                        var result = await PermohonanService.Create(Permohonan);
                        if (result != null)
                        {
                            Helper.Permohonan.Add(result);
                            MessagingCenter.Send(new MessagingCenterAlert { Cancel = "OK", Message = "Permohonan Anda Berhasil dibuat !", Title = "Info" }, "message");
                        }
                    }
                }
                else
                {
                    Permohonan.Data = JObject.FromObject(Model);
                    var result = await PermohonanService.Put(Permohonan);
                }




                IsBusy = false;
            }
            catch (Exception ex)
            {
                MessagingCenter.Send(new MessagingCenterAlert
                {
                    Title = "Error",
                    Message = ex.Message,
                    Cancel = "OK"
                }, "message");
                IsBusy = false;
            }
        }

        private Command saveCommand;

        public Command SaveCommand
        {
            get { return saveCommand; }
            set { SetProperty(ref saveCommand, value); }
        }
    }
}
