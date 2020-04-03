using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

using Xamarin.Forms;

using won.Models;
using won.Services;
using Newtonsoft.Json;
using won.Models.Accounts;

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
}
