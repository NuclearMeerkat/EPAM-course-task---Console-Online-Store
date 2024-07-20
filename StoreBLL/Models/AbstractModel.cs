namespace StoreBLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
public abstract class AbstractModel
{
    protected AbstractModel(int id)
    {
        this.Id = id;
    }

    public int Id { get; private set; }

    /// <summary>
    /// Directive method for changing the ID.
    /// </summary>
    /// <param name="id">Model id.</param>
    public void SetId(int id) => this.Id = id;
}
