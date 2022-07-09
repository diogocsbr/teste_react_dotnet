# teste_react_dotnet

*informações para rodar o banco*

__ criar o banco chamado 'teste_leilao' (sem as aspas)
__ Rodar os scripts de forma sequencial, localizados na pasta 'script' na Raiz do projeto
____ Se o script script_02_criacao_admin.sql for rodado sem alterações e com sucesso, o acesso a api será através do usuário: admin e senha: admin


*informações da Api*

__ Api conta com a segurança via Json Web Token
____  Usuário admin poderá criar produtos, os outros usuários poderão simplesmente visualizar os produtos

__ Api está estruturada com CQRS
__ As regras estão na camada services


*FrontEnd*

__ Não foi desenvolvido, motivo arquivo txt na pasta Frontend

*Observações*

  não foi pedido Deletar ou inativar Produto
  não foi pedido transações
  não foi pedido alteração de senha
  não foi pedido encriptação de senha
  não foi pedido paginação
  não foi pedido a data de nascimento, então somente vou gravar a idade!
  foi pedido que tenha mais de 18 anos e não igual ou maior a 18 anos
			
  a string de conexão está na Infra, a meu ver deveria estar na Services, mas, usando um banco só não tem problema na minha opinião