using System.ComponentModel.DataAnnotations.Schema;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl.EF;

namespace GestaoFuncionarios.Module.BusinessObjects
{
    [DefaultClassOptions]
    public class Pagamento : BaseObject
    {
        [ModelDefault("DisplayFormat", "{0:c}")]
        public virtual double Rate { get; set; }
        public virtual double Hours { get; set; }

        [NotMapped]
        [ModelDefault("DisplayFormat", "{0:c}")]
        public double Amount
        {
            get { return Rate * Hours; }
        }
    }
}
