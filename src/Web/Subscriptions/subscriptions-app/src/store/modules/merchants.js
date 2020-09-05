import merchants from '../../api/merchants'

const state = () => ({
    merchant: {
        loading: true,
        success: false,
        data: null
    }
})

const getters = {
    
    
}

const actions = {
    async getMerchant({ commit })  {
        const data = await merchants.getMerchant(1)
        setTimeout(() => {
            commit('setMerchant', data)
        }, 3000)
    }
}

const mutations = {
    setMerchant(state, merchant){
        state.merchant = {
            loading: false,
            success: merchant !== null,
            data: merchant
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