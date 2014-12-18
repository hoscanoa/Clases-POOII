if OBJECT_ID('SP_listarBarco') is not null
drop proc SP_listarBarco
go

create procedure SP_listarBarco
as
select [COD_BAR], [NOM_BAR] from [dbo].[TB_BARCO]
go

exec SP_listarBarco
go


if OBJECT_ID('SP_listarFaenaxBarco') is not null
drop proc SP_listarFaenaxBarco
go

create procedure SP_listarFaenaxBarco
@codBar char(5)
as
select f.* from TB_BARCO b inner join TB_FAENA f
on b.COD_BAR = f.COD_BAR
where b.COD_BAR = @codBar
go


