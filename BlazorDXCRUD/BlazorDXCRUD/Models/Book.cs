﻿namespace BlazorDXCRUD.Models1
{
    //Clase libro con tres atributos con getter y setter int string string
    public class Book
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }

        //Poner fecha actual por defecto
        public DateTime Date { get; set; } = DateTime.Now;

	}
}
