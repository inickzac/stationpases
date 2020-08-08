using stationpases.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Navigation;

namespace stationpases.VMs
{
    public class OneValueExtendedVM<T> : VMContext where T : class, IOneValue,  new()
    {
        private T selectingValue;
        private T tempSelectedValue;
        private RelayCommand saveChoise;
        private RelayCommand deleteSelectedItem;
        private string searchStr;
        private ICollectionView source;
        private Action<object> callBack;
        public OneValueExtendedVM(T selectingValue, Action<object> callBack)
        {
            this.selectingValue = selectingValue;
            TempSelectedValue = selectingValue;
            searchStr = "";
            source = CollectionViewSource.GetDefaultView(MainBDContext.GetRef.Set<T>().Local);
            source.Filter = o => (o as T).Value.Contains(searchStr);
            this.CallBack = callBack;
        }

        public string Value { get => selectingValue.Value; set => selectingValue.Value = value; }
        public T TempSelectedValue { get => tempSelectedValue; set { tempSelectedValue = value; OnPropertyChanged(); } }
        public string SearchStr { get => searchStr; set { searchStr = value; OnPropertyChanged(); FilteredCollection.Refresh(); } }
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
                  }));
            }
        }
         

    }
}
