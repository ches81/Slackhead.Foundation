using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using Slackhead.Utils;
using UnityEngine;

namespace Slackhead.Statemachine
{
    public class SimpleStatemachine<TBlackboard>
    {
        private Dictionary<Type, IState<TBlackboard>> states = new Dictionary<Type, IState<TBlackboard>>();

        [PublicAPI] public TBlackboard Blackboard { get; }

        private IState<TBlackboard> currentState;

        private Queue<IState<TBlackboard>> queue;


        public SimpleStatemachine()
        {
            Blackboard = Activator.CreateInstance<TBlackboard>();
        }


        [PublicAPI]
        public void AddState(IState<TBlackboard> state)
        {
            if (!states.ContainsKey(state.GetType()))
            {
                state.Initialize(this);
                states.Add(state.GetType(), state);
            }
        }


        [PublicAPI]
        public void Change<T>() where T : IState<TBlackboard>
        {
            Debug.Log($"CHANGE STATE to {typeof(T)}");
            Change(typeof(T));
        }


        [PublicAPI]
        public void Change(Type type)
        {
            if (states.TryGetValue(type, out var nextState))
            {
                SlackConsole.Log($"Change states: {currentState?.GetType().Name ?? "None"}->{nextState.GetType().Name}", Color.green);
                currentState?.Exit();
                currentState = nextState;
                currentState.Enter();
            }
            else
            {
                Debug.LogError($"Could not transit to requested state: {type.Name} because it was not found!");
            }
        }


        [PublicAPI]
        public virtual void Update(float deltaTime)
        {
            currentState?.Update(deltaTime);
        }


        [PublicAPI]
        public virtual void Dispose()
        {
        }
    }
}