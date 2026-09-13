using Microsoft.Maui.Graphics.Text;

namespace Lista_de_Tarefas
{
    public partial class MainPage : ContentPage
    {
        Dictionary<CheckBox, Label> list;
        int tarefasConcluidas;
        int totalTarefas;

        public MainPage()
        {
            InitializeComponent();
            list = new Dictionary<CheckBox, Label>();
        }

        private async void btAdicionar_Clicked(object sender, EventArgs e)
        {
            var newItem = new HorizontalStackLayout();
            var chkTarefa = new CheckBox();
            var lbTarefa = new Label { Text = entryTarefa.Text, VerticalOptions = LayoutOptions.Center };

            if (string.IsNullOrWhiteSpace(entryTarefa?.Text))
            {
                await DisplayAlertAsync("Erro", "Escreva o nome da tarefa", "OK");
                return;
            }

            list[chkTarefa] = lbTarefa;

            newItem.Children.Add(chkTarefa);
            newItem.Children.Add(lbTarefa);

            listaTarefas.Children.Add(newItem);

            entryTarefa.Text = "";

            chkTarefa.CheckedChanged += OnCheckboxChanged;

            totalTarefas = list.Count();

            lbContagem.Text = $"{tarefasConcluidas} de {totalTarefas} tarefas concluídas";
        }

        private void OnCheckboxChanged(object sender, CheckedChangedEventArgs e)
        {
            var chk = sender as CheckBox;

            Label label = list[chk];

            label.TextDecorations = chk.IsChecked ? TextDecorations.Strikethrough : TextDecorations.None;
            label.TextColor = chk.IsChecked ? Colors.Grey : Colors.White;

            tarefasConcluidas = list.Keys.Count(chkTarefa => chkTarefa.IsChecked);

            lbContagem.Text = $"{tarefasConcluidas} de {totalTarefas} tarefas concluídas";
        }
    }
}
