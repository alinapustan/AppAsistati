using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkout
{
    public interface IView //IDefaultView
    {
        String LabelGetName { get; set; }
        String LabelGetSurname { get; set; }
        DateTime LabelGetBirthday { get; set; }
        String NameTextBox { get; set; }
        String SurnameTextBox { get; set; }
        String LabelShowCNP { get; set; }
        String LabelShowName { get; set; }
        String LabelShowSurname { get; set; }
        String LabelShowBirthday { get; set; } 
        String LabelSuccess { get; set; }
    }
}
