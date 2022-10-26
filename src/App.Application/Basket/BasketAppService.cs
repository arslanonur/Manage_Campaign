using App.Basket.Dto;
using App.Campaign.Dto;
using App.Domain.Repositories;
using App.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace App.Basket
{
    public class BasketAppService : IBasketAppService
    {
        private readonly IRepository<Basket> _basketRepository;

        public BasketAppService(IRepository<Basket> basketRepository)
        {
            _basketRepository = basketRepository;
        }

        public void CreateOrEdit(BasketEditDto editDto)
        {
            if (editDto.Id <= 0)
            {
                var entity = editDto.ToEntity<Basket>();
                _basketRepository.Insert(entity);
            }
            else
            {
                var entity = _basketRepository.Get(editDto.Id);

                editDto.ToEntity(entity);
                _basketRepository.Update(entity);
            }
        }

        public void Delete(int id)
        {
            _basketRepository.Delete(id);
        }

        public void DeleteAll()
        {
            var entities = _basketRepository.GetAllList();
            foreach (var entity in entities)
            {
                _basketRepository.Delete(entity);
            }
        }

        public List<BasketListDto> GetAll()
        {
            var entities = _basketRepository.GetAllList();

            return entities.Select(entity => entity.ToModel<BasketListDto>()).ToList();
        }

        public BasketListDto GetForView(int id)
        {
            var entity = _basketRepository.Get(id);

            return entity.ToModel<BasketListDto>();
        }
    }
}
