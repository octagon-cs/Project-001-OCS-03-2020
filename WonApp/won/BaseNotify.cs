using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;

namespace won
{



    public class BaseNotify : INotifyPropertyChanged
    {
        private string nik;

        [JsonProperty("nik")]
        public string NIK
        {
            get { return nik; }
            set
            {
                SetProperty(ref nik, value);
            }
        }


        [JsonIgnore]
        public virtual bool Valid { get; }

        private string error="";

        [JsonIgnore]
        public string ErrorMessage
        {
            get { return error; }
            set { SetProperty(ref error, value); }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        public bool SetProperty<T>(ref T backingStore, T value,
        [CallerMemberName]string propertyName = "", Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }

        public string GetPropertyName<T>(Expression<Func<T>> propertyExpression)
        {
            return (propertyExpression.Body as MemberExpression).Member.Name;
        }
        #region INotifyPropertyChanged



        public void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;
            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
