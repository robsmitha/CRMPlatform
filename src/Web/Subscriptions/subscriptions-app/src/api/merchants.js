import { get } from './api'

export default {
    getMerchant
}

async function getMerchant(id){
    const token = null//authService.getToken()
    var request = {
        method: 'post',
        headers: { 
            'Content-Type': 'application/json',
            'Authorization': `Bearer ${token}` 
        },
        body: JSON.stringify({ MerchantID: merchantId })
    }
    return get(`/merchants/getMerchant`, request)
}