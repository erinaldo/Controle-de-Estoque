CREATE trigger tgiDecrementaEstoqueVenda on itensvenda
for insert
as
BEGIN 
	DECLARE @qtde	float, 
	@codigo			integer
	
	SELECT @codigo = pro_cod, @qtde = itv_qtde FROM INSERTED 
	
	update produto set pro_qtde = pro_qtde - @qtde where produto.pro_cod = @codigo 
end
go

CREATE trigger tgiIncrementaEstoqueCompra on itenscompra
for insert
as
BEGIN 
	DECLARE @qtde	float, 
	@codigo			integer
	
	SELECT @codigo = pro_cod, @qtde = itv_qtde FROM INSERTED 
	
	update produto set pro_qtde = pro_qtde + @qtde where produto.pro_cod = @codigo 
end
go