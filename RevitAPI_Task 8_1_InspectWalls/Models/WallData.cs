namespace RevitAPI_Task_8_1_InspectWalls.Models
{
    /// <summary>
    /// Модель данных с информацией о стене: размеры, объём, площадь и флаг соответствия норме.
    /// </summary>
    public class WallInfo
    {
        /// <summary>Название стены.</summary>
        public string Name { get; set; }

        /// <summary>Тип стены (семейство).</summary>
        public string Type { get; set; }

        /// <summary>Длина стены в мм.</summary>
        public double Length { get; set; }

        /// <summary>Высота стены в мм.</summary>
        public double Height { get; set; }

        /// <summary>Толщина стены в мм.</summary>
        public double Thickness { get; set; }

        /// <summary>Объём стены в м³.</summary>
        public double Volume { get; set; }

        /// <summary>Площадь стены в м².</summary>
        public double Area { get; set; }

        /// <summary>Признак соответствия допустимому пределу толщины.</summary>
        public bool IsCorrect { get; set; }
    }
}
