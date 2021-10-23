namespace Entity
{
    public class TipoInquilinoEntity : DBEntity
    {
        public int? IdTipoInquilino { get; set; }
        public string Descripcion { get; set; }
        public bool Estado { get; set; }
    }
}
