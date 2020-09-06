using stationpases.VMs.interfeses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace stationpases.VMs
{
    class DataErrorInfoTools : IDataErrorInfo       
    {
        string error;
        public List<PropertyInfo> TempRequiredPropertyes { get; set; }
        private object currentObj { get; set; }

        public string Error { get => error; set => error = value; }

        public string this[string columnName]
        {
            get
            {
                string error = String.Empty;
                error = ErrorCommon(columnName);
                Error = error;
                return error;
            }
        }

        public DataErrorInfoTools(object currentObj, Type type)
        {
            this.currentObj = currentObj;
            PropertyInfo[] properties = type.GetProperties();
            var TempRequiredPropertyStrings = properties.ToList()
                .Where(p => Attribute.IsDefined(p, typeof(RequiredAttribute)))
                .Select(p => "Temp" + p.Name)
                .ToList();
            TempRequiredPropertyes = properties.Where(p => TempRequiredPropertyStrings.Contains(p.Name))
                .ToList();
        }

        public string ErrorCommon(string columnName)
        {
            string CommonError = "Введите значение";
            var currentProperty = TempRequiredPropertyes.Where(p => p.Name == columnName).FirstOrDefault().GetValue(currentObj);
            if (currentProperty != null)
            {
                if (currentProperty is string)
                {
                    if (string.IsNullOrEmpty(currentProperty as string))
                    {
                        return CommonError;
                    }
                }
                return string.Empty;
            }
            return CommonError;
        }

    }
}
