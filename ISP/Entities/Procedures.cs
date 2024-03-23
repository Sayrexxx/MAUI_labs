using SQLite;

namespace ISP.Entities;

[Table("Procedures")]
public class Procedures
{
    [PrimaryKey, AutoIncrement, Indexed]
    [Column("Id")]
    public int ProcedureId { get; set; }

    public string Name { get; set; }
    [Indexed] public int ProcedureGroupId { get; set; }
}