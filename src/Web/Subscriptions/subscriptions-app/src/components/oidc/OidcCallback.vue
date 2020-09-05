<template>
    <div>
        Callback
    </div>
</template>
<script>
export default {
    created() {
        //TODO: Move to mixin
        const search = window.location.search
        const params = new URLSearchParams(search)
        if(params){
            const error = params.get('error')
            const token = params.get('id_token')
            if(error){
                const error_description = params.get('error_description')
                console.log(error_description)
            } else if(token) {
                console.log(token)
            }
            else {
                console.log('Token not present.')
            }
        }
        else{
            console.log('Missing parameters.')
        }
    }
}
</script>