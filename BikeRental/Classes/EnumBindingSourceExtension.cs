using System;
using System.Windows.Markup;

namespace BikeRental.Classes
{
    //Extension used to bind Enums to the View
    public class EnumBindingSourceExtension : MarkupExtension
    {
        public Type EnumType { get; set; }

        public EnumBindingSourceExtension(Type enumType)
        {
            if(enumType is null || !enumType.IsEnum)
                throw new Exception("EnumType can not be null and must be of type Enum");    
            
            EnumType = enumType;
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return Enum.GetValues(EnumType);
        }
    }
}
