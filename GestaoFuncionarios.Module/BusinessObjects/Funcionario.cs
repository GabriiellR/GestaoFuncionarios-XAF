using DevExpress.CodeParser;
using DevExpress.ExpressApp.DC;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl.EF;
using GestaoFuncionarios.Module.BusinessObjects;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace MySolution.Module.BusinessObjects;

[DefaultClassOptions]
[ObjectCaptionFormat("{0:NomeCompleto}")]
[DefaultProperty(nameof(NomeCompleto))]
public class Funcionario : BaseObject
{
    public virtual String Nome { get; set; }
    public virtual String Sobrenome { get; set; }
    public virtual String UltimoNome { get; set; }
    [FieldSize(255)]
    public virtual String Email { get; set; }
    public string NomeCompleto
    {
        get { return ObjectFormatter.Format($"{Nome} {Sobrenome} {UltimoNome}", this, EmptyEntriesMode.RemoveDelimiterWhenEntryIsEmpty); }
    }

    public virtual Departamento Departamento { get; set; }
    public virtual Cargo Cargo { get; set; }
    public virtual IList<Tarefa> Tarefas { get; set; } = new ObservableCollection<Tarefa>();
}