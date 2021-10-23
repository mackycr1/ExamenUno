namespace Entity
{
    public class TipoInquilinoEntity : DBEntity
    {
        public int? Id_TipoInquilino { get; set; }
        public string Descripcion { get; set; }
        public bool Estado { get; set; }
    }
}
