# Sistema de Gerenciamento de Estados de Tarefas

### [HttpGet("{id}")]:
Define que este método responde a requisições GET para api/CTask/{id}.
### GetTask(int id):
Busca uma tarefa pelo ID no banco de dados. Se a tarefa não for encontrada, retorna NotFound(), caso contrário, retorna a tarefa.

### [HttpPost]:
Define que este método responde a requisições POST para api/CTask.
### PostTask(StateTaskModel tasksModel):
Cria uma nova tarefa com o estado inicial Created, adiciona ao banco de dados e salva as alterações. Retorna a tarefa criada com um status de criação (201 Created).

### [HttpPut("{id}/start")]:
Define que este método responde a requisições PUT para iniciar uma a Task para api/CTask/{id}/start.
### StartTask(int id):
Encontra a tarefa pelo ID, verifica se seu estado é Created e altera para InProgress. Salva as mudanças e retorna NoContent() se bem-sucedido, ou BadRequest() se a tarefa não puder ser iniciada.

### [HttpPut("{id}/complete")]:
Define que este método responde a requisições PUT para completar a Task api/CTask/{id}/complete.
### CompleteTask(int id):
Encontra a tarefa pelo ID, verifica se seu estado é InProgress e altera para Completed. Salva as mudanças e retorna NoContent() se bem-sucedido, ou BadRequest() se a tarefa não puder ser completada.

### [HttpPut("{id}/cancel")]:
Define que este método responde a requisições PUT para cancelar a Task api/CTask/{id}/cancel.
### CancelTask(int id):
Encontra a tarefa pelo ID, verifica se seu estado é Created ou InProgress e altera para Canceled. Salva as mudanças e retorna NoContent() se bem-sucedido, ou BadRequest() se a tarefa não puder ser cancelada.

## Conclusão
O controlador CTaskController permite criar, recuperar e mudar o estado das tarefas usando métodos assíncronos para interações com o banco de dados. Ele garante que as transições de estado sigam uma lógica específica, utilizando o padrão State para gerenciar essas mudanças.
