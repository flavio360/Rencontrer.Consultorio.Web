namespace Rencontrer.Consultorio.Web.Domain.Entities
{
    public class PacienteViewModel
    {
		public string NomeCompleto { get; set; }
		public DateTime DataNascimento { get; set; }
		public int Sexo { get; set; }
		public string Telefone { get; set; }
		public string Endereco { get; set; }
		public string Email { get; set; }
		public string Observacoes { get; set; }

		public int OrientacaoSexual { get; set; }
		public int FezTerapia { get; set; }
		public string HistoricoPsicologico { get; set; }
		public string ObjetivosTerapia { get; set; }

		public string CondicoesSaude { get; set; }
		public string MedicamentosEmUso { get; set; }
		public string HistoricoFamiliarPsicologico { get; set; }
		public string TraumasEventosSignificativos { get; set; }

		public string RelacionamentosInterpessoais { get; set; }
		public string ObservacoesAdicionais { get; set; }
	}
}
