using SQLite;

namespace ISP.Entities;


[Table("ProcedureGroups")]
public class ProcedureGroups
{
    [PrimaryKey, AutoIncrement, Indexed]
    public int Id { get; set; }
    public string Name { get; set; }
}
