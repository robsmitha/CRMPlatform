import clients from '../../api/clients'

const state = () => ({
    client: {
        loading: true,
        success: false,
        data: null
    }
})

const getters = {
    
    
}

const actions = {
    async getClient({ commit })  {
        const data = await clients.getClient(1)
        setTimeout(() => {
            commit('setClient', data)
        }, 3000)
    }
}

const mutations = {
    setClient(state, client){
        state.client = {
            loading: false,
            success: client !== null,
            data: client
        }
    }
}

export default {
    namespaced: true,
    state,
    getters,
    actions,
    mutations
}