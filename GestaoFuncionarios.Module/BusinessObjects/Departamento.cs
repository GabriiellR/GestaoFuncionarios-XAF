using System.Collections.ObjectModel;
using System.ComponentModel;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl.EF;
using MySolution.Module.BusinessObjects;

namespace GestaoFuncionarios.Module.BusinessObjects
{
    [DefaultClassOptions]
    [DefaultProperty(nameof(Nome))]
    public class Departamento : BaseObject
    {
        public virtual String Nome { get; set; }
        public virtual IList<Funcionario> Funcionarios { get; set; } = new ObservableCollection<Funcionario>();
    }
}
