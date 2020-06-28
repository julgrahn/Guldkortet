namespace Guldkortet
{
    public class Collection<T> //en generisk list-klass som jag tänkte försöka arbeta med, men det får bli till ett senare tillfälle
                               //med lite mer tid och ork så hade jag kunnat använda mig av det här, jag hade bara behövt lägga till en Split()-metod så ska det funka som 
                               //den generiska List<>-metoden
    {
        protected int buffert; //Storlek på buffert
        protected T[] list; //Samling av element av vilken typ som helst
        protected int length; //Antal tillgängliga platser
        protected int amount; //Antal använda platser

        public Collection()
        {
            buffert = 30;
            amount = 0;
            length = 30;
            list = new T[length];
        }

        protected void Expand(int size)
        {
            if (size < 1)
                return;

            T[] temp = new T[length + size];
            for (int i = 0; i < amount; i++)
            {
                temp[i] = list[i];
            }

            list = temp;
            length += size;
        }

        protected void Reduce()
        {
            T[] temp = new T[amount]; //Gör en ny mindre lista

            for (int i = 0; i < amount; i++)
            {
                temp[i] = list[i];
            }

            list = temp;
            length = amount;
        }

        public void AddElement(T e)
        {
            if (amount + 1 > length)
                Expand(1 + buffert);

            list[amount++] = e;
        }

        public T RemoveElement(int index)
        {
            T temp = list[index];

            for (int i = index; i < amount - 1; i++)
            {
                list[i] = list[i + 1];
            }

            amount--;

            if (length - amount > buffert)
            {
                Reduce();
            }

            return temp;
        }


    }
}
