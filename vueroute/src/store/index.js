

const state = {
  count: 0,
  textos:[],
  product:{
    title:"",
    description:"",
    quantity:0
  },
  squares: Array(9).fill(null),
  products:[]
};

const mutations = {
  increment (state) {
    state.count++
  },
  decrement (state) {
    state.count--
  },
  borrarTextos(state) {
    state.textos = [];
  }, 
  guardarTextos(state, payload) {
    state.textos.push(payload.texto);
  }, 
  setSquares (state, payload) {
    state.squares = payload.squares
    console.log(state.squares);
  },
  getSquares (state) {
    return state.squares;
  }
};

const actions = {
  BORRAR_TEXTOS:({commit}, payload)=>{
    commit('borrarTextos', payload);
  },
  GUARDAR_TEXTOS:({commit}, payload)=>{
    commit('guardarTextos', payload);
  },
  DECREMENT:({commit}, payload)=>{
    commit('decrement', payload);
  },
  INCREMENT:({commit}, payload)=>{
    commit('increment', payload);
  },
  SETSQUARES:({commit}, payload)=>{
    commit('setSquares', payload);
  },
  GETSQUARES:({commit}, payload)=>{
    commit('getSquares', payload);
  }
  /* increment (context) {
    context.commit('increment')
  },
  increment ({ commit }) {
    commit('increment')
  },
  incrementAsync ({ commit }) {
    setTimeout(() => {
      commit('increment')
    }, 1000)
  },
  checkout ({ commit, state }, products) {
    // save the items currently in the cart
    const savedCartItems = [...state.cart.added]
    // send out checkout request, and optimistically
    // clear the cart
    commit(types.CHECKOUT_REQUEST)
    // the shop API accepts a success callback and a failure callback
    shop.buyProducts(
      products,
      // handle success
      () => commit(types.CHECKOUT_SUCCESS),
      // handle failure
      () => commit(types.CHECKOUT_FAILURE, savedCartItems)
    )
  } */
}

/* const store = new Vuex.Store({

}); */

//store.dispatch('increment')


  export default{
    namespaced:true,
    state,
    mutations,
    actions
  }

