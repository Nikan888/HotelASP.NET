using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.ViewModels
{
    public enum SortState
    {
        No, // не сортировать
        RoomTypeAsc,    // по цене номера по возрастанию
        RoomTypeDesc,   // по цене номера по убыванию
        ClientFioAsc, // по ФИО клиента по возрастанию
        ClientFioDesc    // по ФИО клиента по убыванию
    }

    public class SortViewModel
    {
        public SortState RoomTypeSort { get; set; } // значение для сортировки по цене номера
        public SortState ClientFioSort { get; set; }    // значение для сортировки по ФИО клиента
        public SortState CurrentState { get; set; }     // текущее значение сортировки

        public SortViewModel(SortState sortOrder)
        {
            RoomTypeSort = sortOrder == SortState.RoomTypeAsc ? SortState.RoomTypeDesc : SortState.RoomTypeAsc;
            ClientFioSort = sortOrder == SortState.ClientFioAsc ? SortState.ClientFioDesc : SortState.ClientFioAsc;
            CurrentState = sortOrder;
        }
    }
}
