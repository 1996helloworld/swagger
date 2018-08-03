using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace AccountApi.Areas.HelpPage.ModelDescriptions
{
    public class EnumTypeModelDescription : ModelDescription
    {
        public EnumTypeModelDescription()
        {
            Values = new Collection<EnumValueDescription>();
        }
        /// <summary>
        /// ����
        /// </summary>
        public Collection<EnumValueDescription> Values { get; private set; }
        /// <summary>
        /// �˻���Ϣ
        /// </summary>
        public Collection<EnumValueDescription> Account { get; set; }
    }
}