CREATE TABLE [usuarios]
( 
	[usu_cod]            int NOT NULL IDENTITY(1,1) ,
	[usu_nome]           varchar(95)  NULL,
	[usu_senha]           varchar(95)  NULL,
	[usu_email]           varchar(95)  NULL,
	[usu_tipo]           	int NOT NULL,
	[usu_ativo]           	bit


)
go

ALTER TABLE [usuarios]
	ADD CONSTRAINT [XPKusuarios] PRIMARY KEY  NONCLUSTERED ([usu_cod] ASC)
go

insert into usuarios(usu_nome,usu_senha,usu_email,usu_tipo,usu_ativo)
values ('root','toor','guizadumodas@hotmail.com',1,1)
insert into usuarios(usu_nome,usu_senha,usu_email,usu_tipo,usu_ativo)
values ('Administrador','123456','ADM@hotmail.com',2,1)
insert into usuarios(usu_nome,usu_senha,usu_email,usu_tipo,usu_ativo)
values ('Gerente','gerente','gerente@hotmail.com',3,1)
insert into usuarios(usu_nome,usu_senha,usu_email,usu_tipo,usu_ativo)
values ('Operador','operador','operador@hotmail.com',4,1)
insert into usuarios(usu_nome,usu_senha,usu_email,usu_tipo,usu_ativo)
values ('teste','teste','teste@hotmail.com',4,0)


CREATE TABLE [categoria]
( 
	[cat_cod]            int  NOT NULL  IDENTITY ( 1,1 ) ,
	[cat_nome]           varchar(95)  NULL 
)
go

ALTER TABLE [categoria]
	ADD CONSTRAINT [XPKcategoria] PRIMARY KEY  NONCLUSTERED ([cat_cod] ASC)
go

CREATE TABLE [cliente]
( 
	[cli_cod]            int  NOT NULL  IDENTITY ( 1,1 ) ,
	[cli_nome]           varchar(95)  NULL ,
	[cli_cpfcnpj]        varchar(95)  NULL ,
	[cli_rgie]           varchar(95)  NULL ,
	[cli_rsocial]        varchar(95)  NULL ,
	[cli_tipo]           varchar(20)  NULL ,
	[cli_cep]            varchar(20)  NULL ,
	[cli_endereco]       varchar(95)  NULL ,
	[cli_bairro]         varchar(95)  NULL ,
	[cli_fone]           varchar(95)  NULL ,
	[cli_cel]            varchar(95)  NULL ,
	[cli_email]          varchar(95)  NULL ,
	[cli_endnumero]      varchar(10)  NULL ,
	[cli_cidade]         varchar(95)  NULL ,
	[cli_estado]         varchar(95)  NULL ,
	[cli_datanasc]         varchar(95)  NULL ,
	[cli_localtrabalho]         varchar(95)  NULL ,
	[cli_fonetrabalho]         varchar(95)  NULL 
)
go

ALTER TABLE [cliente]
	ADD CONSTRAINT [XPKcliente] PRIMARY KEY  NONCLUSTERED ([cli_cod] ASC)
go

CREATE TABLE [compra]
( 
	[com_cod]            int  NOT NULL  IDENTITY ( 1,1 ) ,
	[com_data]           datetime  NULL ,
	[com_pagto_data]     datetime  NULL ,
	[com_nfiscal]        int  NULL ,
	[com_pagto_total]          numeric(8,2) NULL ,
	[com_pagto_dinheiro]          numeric(8,2)  NULL ,
	[com_pagto_cartao]          numeric(8,2)  NULL ,
	[com_nparcela]      int  NULL ,
	[com_status]         int  NULL ,
	[for_cod]            int  NULL ,
	[tpa_cod]            int  NULL 
)
go

ALTER TABLE [compra]
	ADD CONSTRAINT [XPKcompra] PRIMARY KEY  NONCLUSTERED ([com_cod] ASC)
go

CREATE TABLE [parcelascompra]
( 
	[pco_cod]            int  NOT NULL ,
	[pco_valor]          numeric(8,2)  NULL ,
	[pco_datapagto]      date  NULL ,
	[pco_datavecto]      date  NULL ,
	[pco_status]         int  NULL,	
	[com_cod]            int  NOT NULL
	
 
)
go

ALTER TABLE [parcelascompra]
	ADD CONSTRAINT [XPKparcelascompra] PRIMARY KEY  CLUSTERED ([pco_cod] ASC,[com_cod] ASC)
go

CREATE TABLE [fornecedor]
( 
	[for_cod]            int  NOT NULL  IDENTITY ( 1,1 ) ,
	[for_nome]           varchar(95)  NULL ,
	[for_rsocial]        varchar(95)  NULL ,
	[for_ie]             varchar(95)  NULL ,
	[for_cnpj]           varchar(95)  NULL ,
	[for_cep]            varchar(95)  NULL ,
	[for_endereco]       varchar(95)  NULL ,
	[for_bairro]         varchar(95)  NULL ,
	[for_fone]           varchar(95)  NULL ,
	[for_cel]            varchar(95)  NULL ,
	[for_email]          varchar(95)  NULL ,
	[for_endnumero]      varchar(95)  NULL ,
	[for_cidade]         varchar(95)  NULL ,
	[for_estado]         varchar(95)  NULL 
)
go

ALTER TABLE [fornecedor]
	ADD CONSTRAINT [XPKfornecedor] PRIMARY KEY  NONCLUSTERED ([for_cod] ASC)
go

CREATE TABLE [produto]
( 
	[pro_cod]            int  NOT NULL  IDENTITY ( 1,1 ) ,
	[pro_nome]           varchar(95)  NULL ,
	[pro_descricao]      text  NULL ,
	[pro_foto]           image  NULL ,
	[pro_valorpago]      numeric(8,2)  NULL ,
	[pro_valorvenda]     numeric(8,2)  NULL ,
	[pro_qtde]           int  NULL ,
	[umed_cod]           int  NULL ,
	[cat_cod]            int  NULL ,
	[scat_cod]           int  NULL ,
	[pro_tamanho]           varchar(1)  NULL ,
	[pro_codigobarras]           varchar(95)  NULL 

)
go

ALTER TABLE [produto]
	ADD CONSTRAINT [XPKproduto] PRIMARY KEY  NONCLUSTERED ([pro_cod] ASC)
go

CREATE TABLE [itenscompra]
( 
	[itc_cod]            int  NOT NULL ,
	[itc_qtde]           int  NULL ,
	[itc_valor]          numeric(8,2)  NULL ,
	[com_cod]            int  NOT NULL ,
	[pro_cod]            int  NOT NULL 
)
go

ALTER TABLE [itenscompra]
	ADD CONSTRAINT [XPKitenscompra] PRIMARY KEY  NONCLUSTERED ([itc_cod] ASC,[com_cod] ASC,[pro_cod] ASC)
go

CREATE TABLE [subcategoria]
( 
	[scat_cod]           int  NOT NULL  IDENTITY ( 1,1 ) ,
	[scat_nome]          varchar(95)  NULL ,
	[cat_cod]            int  NULL 
)
go

ALTER TABLE [subcategoria]
	ADD CONSTRAINT [XPKsubcategoria] PRIMARY KEY  NONCLUSTERED ([scat_cod] ASC)
go

CREATE TABLE [tipopagamento]
( 
	[tpa_cod]            int  NOT NULL IDENTITY (1,1) ,
	[tpa_nome]           varchar(90)  NULL 
)
go

ALTER TABLE [tipopagamento]
	ADD CONSTRAINT [XPKtipopagamento] PRIMARY KEY  CLUSTERED ([tpa_cod] ASC)
go

insert into tipopagamento(tpa_nome)
values ('CARTÃO')
insert into tipopagamento(tpa_nome)
values ('DINHEIRO')
insert into tipopagamento(tpa_nome)
values ('PROMISSÓRIA')
insert into tipopagamento(tpa_nome)
values ('BOLETO')
insert into tipopagamento(tpa_nome)
values ('CHEQUE')



CREATE TABLE [undmedida]
( 
	[umed_cod]           int  NOT NULL  IDENTITY ( 1,1 ) ,
	[umed_nome]          varchar(95)  NULL 
)
go

ALTER TABLE [undmedida]
	ADD CONSTRAINT [XPKmedida] PRIMARY KEY  NONCLUSTERED ([umed_cod] ASC)
go

CREATE TABLE [venda]
( 
	[ven_cod]            int  NOT NULL  IDENTITY ( 1,1 ) ,
	[ven_data]           datetime  NULL ,
	[ven_data_pagto]     datetime  NULL ,
	[ven_nfiscal]        int  NULL ,
	[ven_pagto_total]          numeric(8,2)  NULL ,
	[ven_pagto_dinheiro]          numeric(8,2)  NULL ,
	[ven_pagto_cartao]          numeric(8,2)  NULL ,
	[ven_nparcela]      int  NULL ,
	[ven_status]         int  NULL ,
	[cli_cod]            int  NULL ,
	[tpa_cod]            int  NULL 
)
go

ALTER TABLE [venda]
	ADD CONSTRAINT [XPKvenda] PRIMARY KEY  NONCLUSTERED ([ven_cod] ASC)
go

CREATE TABLE [itensvenda]
( 
	[itv_cod]            int  NOT NULL ,
	[itv_qtde]           int  NULL ,
	[itv_valor]          numeric(8,2)  NULL ,
	[ven_cod]            int  NOT NULL ,
	[pro_cod]            int  NOT NULL 
)
go

ALTER TABLE [itensvenda]
	ADD CONSTRAINT [XPKitensVenda] PRIMARY KEY  NONCLUSTERED ([itv_cod] ASC,[ven_cod] ASC,[pro_cod] ASC)
go

CREATE TABLE [parcelasvenda]
( 
	[ven_cod]            int  NOT NULL ,
	[pve_cod]            int  NOT NULL ,
	[pve_valor]          numeric(8,2)  NULL ,
	[pve_datapagto]      date  NULL ,
	[pve_datavecto]      date  NULL,
	[pve_status]         int  NULL,
	[cli_cod]            int  NOT NULL 
 
)
go

ALTER TABLE [parcelasvenda]
	ADD CONSTRAINT [XPKparcelasvenda] PRIMARY KEY  CLUSTERED ([ven_cod] ASC,[pve_cod] ASC)
go


CREATE TABLE [nota]
( 
	[emp_nomefantasia]         varchar(95)  NULL ,	
	[emp_cidade]           varchar(95)  NULL ,
	[emp_cep]        varchar(95)  NULL ,
	[emp_endereco]           varchar(95)  NULL ,
	[emp_cnpj]        varchar(95)  NULL ,
	[emp_ie]           varchar(20)  NULL ,
	[emp_im]            varchar(20)  NULL ,
	[emp_telefone]       varchar(95)  NULL ,
	[nt_cod]            int  NOT NULL  IDENTITY ( 1,1 ),
	[pro_cod]            int NULL ,
	[pro_nome]         varchar(95)  NULL ,
	[pro_qtde]           int  NULL ,
	[pro_valorvenda]            numeric(8,2)  NULL ,
	[pro_valortotal]            numeric(8,2)  NULL ,
	[nt_valortotal]            numeric(8,2)  NULL ,
	[nt_valorimposto]            numeric(8,2)  NULL
)
go

ALTER TABLE [nota]
	ADD CONSTRAINT [XPKnota] PRIMARY KEY  NONCLUSTERED ([nt_cod] ASC)
go

CREATE TABLE [empresa]
( 
	[emp_cod]            int  NOT NULL  IDENTITY ( 1,1 ),
	[emp_nome]         varchar(95)  NULL ,	
	[emp_nomefantasia]         varchar(95)  NULL ,	
	[emp_cnpj]           varchar(95)  NULL ,
	[emp_endereconumero]        varchar(95)  NULL ,
	[emp_telefone]           varchar(95)  NULL ,
	[emp_cidade]        varchar(95)  NULL ,
	[emp_estado]           varchar(20)  NULL ,
	[emp_cep]            varchar(20)  NULL
)
go

ALTER TABLE [empresa]
	ADD CONSTRAINT [XPKempresa] PRIMARY KEY  NONCLUSTERED ([emp_cod] ASC)
go

ALTER TABLE [parcelasvenda]
	ADD CONSTRAINT [R_5] FOREIGN KEY ([cli_cod]) REFERENCES [cliente]([cli_cod])
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go

ALTER TABLE [compra]
	ADD CONSTRAINT [R_21] FOREIGN KEY ([for_cod]) REFERENCES [fornecedor]([for_cod])
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go

ALTER TABLE [compra]
	ADD CONSTRAINT [R_24] FOREIGN KEY ([tpa_cod]) REFERENCES [tipopagamento]([tpa_cod])
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go


ALTER TABLE [parcelascompra]
	ADD CONSTRAINT [R_25] FOREIGN KEY ([com_cod]) REFERENCES [compra]([com_cod])
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go


ALTER TABLE [produto]
	ADD CONSTRAINT [R_9] FOREIGN KEY ([umed_cod]) REFERENCES [undmedida]([umed_cod])
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go

ALTER TABLE [produto]
	ADD CONSTRAINT [R_11] FOREIGN KEY ([cat_cod]) REFERENCES [categoria]([cat_cod])
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go

ALTER TABLE [produto]
	ADD CONSTRAINT [R_12] FOREIGN KEY ([scat_cod]) REFERENCES [subcategoria]([scat_cod])
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go


ALTER TABLE [itenscompra]
	ADD CONSTRAINT [R_15] FOREIGN KEY ([com_cod]) REFERENCES [compra]([com_cod])
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go

ALTER TABLE [itenscompra]
	ADD CONSTRAINT [R_17] FOREIGN KEY ([pro_cod]) REFERENCES [produto]([pro_cod])
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go


ALTER TABLE [subcategoria]
	ADD CONSTRAINT [R_10] FOREIGN KEY ([cat_cod]) REFERENCES [categoria]([cat_cod])
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go


ALTER TABLE [venda]
	ADD CONSTRAINT [R_20] FOREIGN KEY ([cli_cod]) REFERENCES [cliente]([cli_cod])
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go

ALTER TABLE [venda]
	ADD CONSTRAINT [R_23] FOREIGN KEY ([tpa_cod]) REFERENCES [tipopagamento]([tpa_cod])
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go


ALTER TABLE [itensvenda]
	ADD CONSTRAINT [R_13] FOREIGN KEY ([ven_cod]) REFERENCES [venda]([ven_cod])
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go

ALTER TABLE [itensvenda]
	ADD CONSTRAINT [R_14] FOREIGN KEY ([pro_cod]) REFERENCES [produto]([pro_cod])
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go


ALTER TABLE [parcelasvenda]
	ADD CONSTRAINT [R_22] FOREIGN KEY ([ven_cod]) REFERENCES [venda]([ven_cod])
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go

ALTER TABLE [nota]
	ADD CONSTRAINT [R_29] FOREIGN KEY ([pro_cod]) REFERENCES [produto]([pro_cod])
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go

/*ALTER TABLE [empresa]
	ADD CONSTRAINT [R_30] FOREIGN KEY ([emp_cod]) REFERENCES [empresa]([emp_cod])
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go*/

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
	
	SELECT @codigo = pro_cod, @qtde = itc_qtde FROM inserted 
	
	update produto set pro_qtde = pro_qtde + @qtde where produto.pro_cod = @codigo 
end
go