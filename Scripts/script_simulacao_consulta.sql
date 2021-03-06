USE [teste_leilao]
GO

-- Consulta onde é possível extrair todos os lances realizados em um produto;
select 
	p.nome,
	l.valor,
	l.data
from 
	lance l inner join produto p on l.produto_id = p.id 
where 
	p.id = 1
order by 
	l.valor
desc

--Consulta onde é possível visualizar o maior lance agrupado por produto;
select 
	p.nome, max(l.valor)
from 
	lance l inner join produto p on l.produto_id = p.id 
group by 
	p.nome