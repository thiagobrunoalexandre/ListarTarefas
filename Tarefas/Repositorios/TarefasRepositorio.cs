using Tarefas.Data;
using Tarefas.Models;
using Tarefas.Repositorios.Interface;
using Microsoft.EntityFrameworkCore;

namespace Tarefas.Repositorios
{
    public class TarefasRepositorio : ITarefaRepositorio
    {
        private readonly TarefasDBContex _dBContex;
        public TarefasRepositorio(TarefasDBContex TarefasDBContex)
        {
            _dBContex = TarefasDBContex;
        }

        public async Task<TarefaModels> BuscarPorId(int id)
        {
            return await _dBContex.tarefas.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<TarefaModels>> BuscarTodasTarefas()
        {
            return await _dBContex.tarefas.ToListAsync();
        }

        public async Task<TarefaModels> Adicionar(TarefaModels tarefa)
        {
           await _dBContex.tarefas.AddAsync(tarefa);
            await _dBContex.SaveChangesAsync();
            return tarefa;
        }
        public async Task<TarefaModels> Atualizar(TarefaModels tarefa, int id)
        {
            TarefaModels TarefaporId = await BuscarPorId(id);
            if (TarefaporId == null)
            {
                throw new Exception($"tarefa para o ID:{id} não foi encontrada no banco de dados.");
            }
            TarefaporId.Name = tarefa.Name;
            TarefaporId.Description = tarefa.Description;

            _dBContex.tarefas.Update(TarefaporId);
            await _dBContex.SaveChangesAsync();
            return TarefaporId;
        }

        public  async Task<bool> Deletar(int id)
        {
            TarefaModels TarefaporId = await BuscarPorId(id);
            if (TarefaporId == null)
            {
                throw new Exception($"tarefa para o ID:{id} não foi encontrada no banco de dados.");
            }
            _dBContex.tarefas.Remove(TarefaporId);
            await _dBContex.SaveChangesAsync();
            return true;
        }




    }
}
