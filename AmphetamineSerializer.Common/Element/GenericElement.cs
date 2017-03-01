﻿using AmphetamineSerializer.Common.Element;
using Sigil.NonGeneric;
using System;

namespace AmphetamineSerializer.Common
{
    /// <summary>
    /// Manage a generic element.
    /// </summary>
    public class GenericElement : BaseElement
    {
        private Type rootType;
        private Type elementType;

        #region Conversions
        /// <summary>
        /// Build a GenericElement wrapper around an action that load the element in the stack.
        /// </summary>
        /// <param name="load">Action to load the element</param>
        public static implicit operator GenericElement(Action<Emit, TypeOfContent> load)
        {
            return new GenericElement(load, null);
        }

        /// <summary>
        /// Build a GenericElement wrapper around an action that store in the element something
        /// taken from the stack.
        /// </summary>
        /// <param name="store">Action that store a value in the element</param>
        public static implicit operator GenericElement(Action<Emit, IElement, TypeOfContent> store)
        {
            return new GenericElement(null, store);
        }

        #endregion

        /// <summary>
        /// Initialize the object with actions.
        /// </summary>
        /// <param name="loadAction">Action that load the element in the stack</param>
        /// <param name="storeAction">Action that store a value in the element</param>
        public GenericElement(Action<Emit, TypeOfContent> loadAction, Action<Emit, IElement, TypeOfContent> storeAction)
        {
            Load = loadAction;
            Store = storeAction;
        }

        /// <summary>
        /// Initialize the object with null action.
        /// </summary>
        public GenericElement()
        {
        }

        /// <summary>
        /// Action for emitting instructions to load the element in the stack.
        /// </summary>
        public override Action<Emit, TypeOfContent> Load { get; set; }

        /// <summary>
        /// Action for emitting instructions that store in the element a value taken from the stack.
        /// </remarks>
        public override Action<Emit, IElement, TypeOfContent> Store { get; set; }

        /// <summary>
        /// If the GenericElement supports type that can be indexed, this is the index.
        /// </summary>
        public override IElement Index { get; set; }

        /// <summary>
        /// If it is well defined, this is the type of the element loaded.
        /// </summary>
        public override Type ElementType
        {
            get
            {
                if (elementType == null)
                    elementType = RootType;
                return elementType;
            }
            set
            {
                elementType = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public override Type RootType
        {
            get
            {
                return rootType;
            }

            set
            {
                rootType = value;
                ElementType = value;
            }
        }

        protected override Action<Emit, IElement, TypeOfContent> InternalStore(IElement index)
        {
            throw new NotImplementedException();
        }

        protected override Action<Emit, TypeOfContent> InternalLoad(IElement index)
        {
            throw new NotImplementedException();
        }
    }
}
