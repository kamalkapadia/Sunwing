using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sunwing.Services
{
	public abstract class EntitiyMapperViewModel<TViewModel, TEntity>
		where TEntity : class
		where TViewModel :  class	
	{
		/// <summary>
		/// Maps a entity to a view model instance.
		/// </summary>
		public static TViewModel MapFromEntity(TEntity model)
		{
			Mapper.CreateMap<TEntity, TViewModel>();

			return Mapper.Map<TViewModel>(model);
		}

		/// <summary>
		/// Maps the specified view model to a entity object.
		/// </summary>
		public TEntity MapToEntity()
		{
			Mapper.CreateMap<TViewModel, TEntity>();
			// Map the derived class to the represented view model
			return Mapper.Map<TEntity>(CastToDerivedClass(this));
		}

		/// <summary>
		/// Gets the derived class.
		/// </summary>
		private static TViewModel CastToDerivedClass(EntitiyMapperViewModel<TViewModel, TEntity> baseInstance)
		{
			return Mapper.Map<TViewModel>(baseInstance);
		}
	}
}
