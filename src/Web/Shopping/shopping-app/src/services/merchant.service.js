
import { sendRequest } from './api.service'
import { authService } from './auth.service'
export const merchantService = {
    getMerchant
};
async function getMerchant (merchantId) {
    const token = authService.getToken()
    var request = {
        method: 'post',
        headers: { 
            'Content-Type': 'application/json',
            'Authorization': `Bearer ${token}` 
        },
        body: JSON.stringify({MerchantID: merchantId})
    }
    return sendRequest(`/merchants/getMerchant`,request)
}