namespace Common.Errors
{
    public static class BusinessErrorCode
    {
        public const string RecursoNoEncontrado = "BE_404";
        public const string ReglasNegocioNoCumplidas = "BE_418";
        public const string ErrorInterno = "BE_500";
        public const string BadGateway = "BE_502";
        public const string ParametrosFaltantes = "BE_600";
        public const string ParametrosFormatoInvalido = "BE_601";
        public const string ParametrosDesconocidos = "BE_602";
        public const string ActivacionInvalida = "BE_603";
        public const string ErrorNegocioPorIntegracion = "BE_605";
        public const string ParametrosIncompatibles = "BE_606";

        public const string LoginUserDataEmpty = "BE_607";
        public const string LoginUserInvalid = "BE_608";

        public static bool IsResourceNotFound(string code)
        {
            return code.Equals(RecursoNoEncontrado);
        }
    }
}
