using stationpases.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data.Entity;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Navigation;

namespace stationpases.VMs
{
    public class OneValueExtendedVM<T> : VMContext, INotifyPropertyChanged where T : class, IOneValue, new()
    {
        private T selectingValue;
        private T tempSelectedValue;
        private RelayCommand saveChoise;
        private string searchStr;
        private ICollectionView source;
        private Action<object> callBack;
        private bool readyToDelete;
        public OneValueExtendedVM(T selectingValue, Action<object> callBack)
        {
            this.selectingValue = selectingValue;
            TempSelectedValue = selectingValue;
            searchStr = "";
            source = new CollectionViewSource { Source = MainBDContext.GetRef.Set<T>().Local }.View;
            source.Filter = o => (o as T).Value.Contains(searchStr);
            this.CallBack = callBack;
        }

        public bool ReadyToDelete
        {
            get => readyToDelete;
            set { readyToDelete = value; OnPropertyChanged(); }
        }
        public string Value { get => selectingValue.Value; set => selectingValue.Value = value; }
        public T TempSelectedValue
        {
            get => tempSelectedValue; set
            {
                tempSelectedValue = value; OnPropertyChanged();
                ReadyToDelete = !ReadyToDelete;
            }
        }
        public string SearchStr
        {
            get => searchStr; set
            {
                searchStr = value; OnPropertyChanged();
                FilteredCollection.Refresh();
            }
        }
        public ICollectionView FilteredCollection { get => source; }
        public Action<object> CallBack { get => callBack; set => callBack = value; }
        public RelayCommand SaveChoise
        {
            get
            {
                return saveChoise ??
                  (saveChoise = new RelayCommand(obj =>
                  {
                      selectingValue = TempSelectedValue;
                      displayRootRegistry.HidePresentation(this);
                      callBack?.Invoke(selectingValue);
                  }, obj => ReadyToDelete = TempSelectedValue != null));
            }
        }



    }
}
