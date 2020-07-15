CREATE PROC FI_SP_PesquisaBeneficiarioPorCPF
	@CPF	VARCHAR(11) = NULL
AS
BEGIN	
	SELECT ID, NOME, CPF, IDCLIENTE 
	FROM BENEFICIARIOS WITH(NOLOCK)
	WHERE
		((CPF = @CPF) OR (@CPF IS NULL))
END