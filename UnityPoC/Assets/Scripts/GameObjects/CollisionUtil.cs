using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionUtil
{
    
    public class Mask
    {
        private int _value = 0;

        public int value
        {
            get
            {
                return _value;
            }
        }

        public Mask() {}

        public Mask(int mask)
        {
            _value = mask;
        }

        public Mask addLayer(string name)
        {
            return addLayer(LayerMask.NameToLayer(name));
        }

        public Mask addLayer(int val)
        {
            _value |= (1 << val);
            return this;
        }

        public Mask removeLayer(string name)
        {
            return removeLayer(LayerMask.NameToLayer(name));
        }

        public Mask removeLayer(int val)
        {
            _value &= ~(1 << val);
            
            return this;
        }

        public bool hasLayer(string name)
        {
            return hasLayer(LayerMask.NameToLayer(name));
        }

        public bool hasLayer(int val)
        {
            return (_value & (1 << val)) != 0;
        }

        public bool hasLayer(Mask val)
        {
            return hasLayer(val.value);
        }
    }

}