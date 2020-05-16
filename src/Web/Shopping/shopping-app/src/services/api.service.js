import appConfig from './../app.config.json'
import { authService } from './auth.service'

export async function sendRequest(func) {
    const token = authService.appUserValue.token
    try {
        const response = await fetch(appConfig.api_endpoint + func, {
            headers: { 'Authorization': `Bearer ${token}` }
        })
        if(response.ok){
            const data = await response.json()
            return data
        }
        else{
            switch(response.status){
                case 401: return 'Unauthorized api call'    //TODO: remove token
                default: return JSON.stringify(response)
            }
        }
    } catch (error) {
        return error.message
    }
}

export function b2cLoginUrl() {
    return `https://${appConfig.directory}.b2clogin.com/${appConfig.directory}.onmicrosoft.com/oauth2/v2.0/authorize?p=${appConfig.signin_signup_userflow}&client_id=${appConfig.client_id}&nonce=${appConfig.nonce}&redirect_uri=${appConfig.redirect_uri}&scope=${appConfig.scope}&response_type=${appConfig.response_type}&prompt=${appConfig.prompt}&response_mode=${appConfig.response_mode}`
}

