using ISP.Entities;
using ISP.Services;

namespace ISP;

public partial class SpaPage : ContentPage
{
    private readonly IDbService _dbService;
    public SpaPage(IDbService dbService)
    {
        InitializeComponent();
        _dbService = dbService;
        PopulatePicker();
    }

    private void PopulatePicker()
    {
        IEnumerable<ProcedureGroups> procedureGroups = _dbService.GetAllProcedureGroups();

        groupPicker.ItemsSource = procedureGroups.Select(procedureGroups => procedureGroups.Name).ToList();
        groupPicker.SelectedIndexChanged += OnPickerSelectedIndexChanged;
    }
    private void OnPickerSelectedIndexChanged(object sender, EventArgs e)
    {
        IEnumerable<ProcedureGroups> procedureGroups = _dbService.GetAllProcedureGroups();
        var selectedGroup = procedureGroups.FirstOrDefault(procedureGroups => procedureGroups.Name == groupPicker.SelectedItem.ToString());
        if (selectedGroup != null)
        {
            IEnumerable<Procedures> procedures = _dbService.GetAllProcedures(selectedGroup.Id);

            collectionView.ItemsSource = procedures;
        }
    }
}