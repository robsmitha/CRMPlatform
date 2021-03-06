const endpoint = process.env.VUE_APP_GATEWAY_WEB_SUBSCRIPTIONS

export async function get(func, request) {
    try {
        const response = await fetch(endpoint + func, request)
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