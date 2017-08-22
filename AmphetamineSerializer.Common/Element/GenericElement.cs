﻿using AmphetamineSerializer.Common.Element;
using Sigil.NonGeneric;
using System;
using AmphetamineSerializer.Common.Attributes;

namespace AmphetamineSerializer.Common
{
    /// <summary>
    /// Manage a generic element.
    /// </summary>
    public class GenericElement : BaseElement
    {
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

        Action<Emit, TypeOfContent> load;
        Action<Emit, IElement, TypeOfContent> store;

        /// <summary>
        /// Initialize the object with actions.
        /// </summary>
        /// <param name="loadAction">Action that load the element in the stack</param>
        /// <param name="storeAction">Action that store a value in the element</param>
        public GenericElement(Action<Emit, TypeOfContent> loadAction, Action<Emit, IElement, TypeOfContent> storeAction)
        {
            load = loadAction;
            store = storeAction;
        }

        /// <summary>
        /// Initialize the object with null action.
        /// </summary>
        public GenericElement(Type loadedType)
        {
            base.loadedType = loadedType;
        }

        /// <summary>
        /// Action for emitting instructions to load the element in the stack.
        /// </summary>
        public override Action<Emit, TypeOfContent> Load
        {
            get { return load; }
            set { load = value; }
        }

        /// <summary>
        /// Action for emitting instructions that store in the element a value taken from the stack.
        /// </remarks>
        public override Action<Emit, IElement, TypeOfContent> Store
        {
            get { return store; }
            set { store = value; }
        }

        public override ASIndexAttribute Attribute { get; set; }

        protected override void InternalLoad(Emit g, TypeOfContent content)
        {
            throw new NotImplementedException();
        }

        protected override void InternalStore(Emit g, TypeOfContent content)
        {
            throw new NotImplementedException();
        }
    }
}
