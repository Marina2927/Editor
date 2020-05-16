using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Editor.DataAccess;
using Editor.DataAccess.DataObjects;

namespace Editor.DataAccess
{
    class IsValid
    {
        private AirportEntities airportEntities;
        private LimitsDataLink limitsDatalink;
        public bool isCityNameValid(string cityName)
        {
            if (cityName == "")
            {
                MessageBox.Show("Пожалуйста введите название города");
                return false;
            }

            return true;
        }
        public bool isDistanceValid(string distance)
        {
            if (distance == ""){
                MessageBox.Show("Пожалуйста введите дальность полета");
                return false;
            }
            else if (Convert.ToInt32(distance) == 0)
            {
                MessageBox.Show("Дальность полета должна быть больше 0");
                return false;
            }
            return true;
        }
        public bool isStartFinishValid(int start, int finish)
        {
            if (start == -1)
            {
                MessageBox.Show("Пожалуйста выберете место отправления");
                return false;
            }
            else if (finish == -1)
            {
                MessageBox.Show("Пожалуйста выберете место назначения");
                return false;
            }
            else if (start == finish)
            {
                MessageBox.Show("Место отправления и место назначения не должны совпадать");
                return false;
            }
            return true;
        }
        public bool isStartFinishValid(string start, string finish)
        {
            if (start == "")
            {
                MessageBox.Show("Пожалуйста введите нач. ограничение");
                return false;
            }
            else if (finish == "")
            {
                MessageBox.Show("Пожалуйста введите кон. ограничение");
                return false;
            }
            int s = Convert.ToInt32(start);
            int f = Convert.ToInt32(finish);
            if (s == f)
            {
                MessageBox.Show("Нач. и кон. ограничения не должны совпадать");
                return false;
            }
            else if (s >= f)
            {
                MessageBox.Show("Нач. ограничение не может быть больше кон.");
                return false;
            }            
            return true;
        }
        public bool isPlaneTypeValid(int type)
        {
            if (type == -1)
            {
                MessageBox.Show("Пожалуйста выберете тип самолета");
                return false;
            }
            return true;
        }
        public bool isNumberValid(string number)
        {
            if (number == ""){
                MessageBox.Show("Пожалуйста введите номер самолета");
                return false;
            }
            return true;
        }
        public bool isSpeedValid(string speed)
        {
            if (speed == "")
            {
                MessageBox.Show("Пожалуйста введите скорость самолета");
                return false;
            }
            else if (speed == "0")
            {
                MessageBox.Show("Скорость самолета должна быть больше 0");
                return false;
            }
            return true;
        }
        public bool isSpeedTypeValid(string type, int speed)
        {
            airportEntities = new AirportEntities();
            limitsDatalink = new LimitsDataLink();
            int start = limitsDatalink.RetrieveSpeedStart(type);
            int finish = limitsDatalink.RetrieveSpeedFinish(type);
            if (speed < start || speed > finish)
            {
                MessageBox.Show("Скорость самолета не удовлетворяет ограничениям: от " + start.ToString() + " до " + finish.ToString());
                return false;
            }
            return true;
        }
        public bool isAirportRouteValid(int route)
        {
            if (route == -1)
            {
                MessageBox.Show("Пожалуйства выберете маршрут");
                return false;
            }
            return true;
        }
        public bool isTimeRouteValid(int time)
        {
            if (time == -1)
            {
                MessageBox.Show("Пожалуйства выберете маршрут");
                return false;
            }
            return true;
        }
        public bool isTimeValid(string startHour, string startMin, string finishHour, string finishMin)
        {
            if (startHour == "")
            {
                MessageBox.Show("Пожалуйства введите часы вылета");
                return false;
            }
            else if (startMin == "")
            {
                MessageBox.Show("Пожалуйства введите минуты вылета");
                return false;
            }
            else if (finishHour == "")
            {
                MessageBox.Show("Пожалуйства введите часы прилета");
                return false;
            }
            else if (finishMin == "")
            {
                MessageBox.Show("Пожалуйства введите минуты прилета");
                return false;
            }
            else if ((Convert.ToInt32(startHour) >= 24) || (Convert.ToInt32(finishHour) >= 24))
            {
                MessageBox.Show("Часы должны быть в пределах от 0 до 23");
                return false;
            }
            else if ((Convert.ToInt32(startMin) >= 60) || (Convert.ToInt32(finishMin) >= 60))
            {
                MessageBox.Show("Минуты должны быть в пределах от 0 до 59");
                return false;
            }
            else if ((Convert.ToInt32(startHour) * 60 + (Convert.ToInt32(startMin))) >= (Convert.ToInt32(finishHour) * 60 + (Convert.ToInt32(finishMin))))
            {
                MessageBox.Show("Время вылета не должно быть больше или совпадать со временем прилета");
                return false;
            }
            return true;
        }
    }
}
