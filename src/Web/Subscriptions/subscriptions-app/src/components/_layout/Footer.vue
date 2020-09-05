<template>
  <v-footer
    v-if="isHomePage"
    dark
    padless
  >
    <v-card
      flat
      tile
      class="dark flex white--text text-center"
    >
    <v-card-text v-if="client.loading">
      <v-progress-circular
            indeterminate
            color="white"
        ></v-progress-circular>
      </v-card-text>
      <v-card-text v-else-if="client.success" class="pb-0">
        <v-btn
          v-for="item in client.data.socialMedia" 
          :key="item.href"
          :href="item.href" 
          icon
          target="_blank" 
          class="mx-4 white--text"
          rel="noopener noreferrer">
          <v-icon size="24px">{{ item.icon }}</v-icon>
        </v-btn>
      </v-card-text>

      <v-card-text class="white--text pt-0">
        <v-skeleton-loader
        width="12rem"
        v-if="client.loading"
        type="text"
        class="mx-auto"
        ></v-skeleton-loader>
        <v-card-text v-else-if="client.success">{{client.data.fullName}}</v-card-text> 
        &copy; {{ new Date().getFullYear() }}
      </v-card-text>
    </v-card>
  </v-footer>
</template>

<script>
import { mapState } from 'vuex'
export default {
    data: () => ({
        items: []
    }),
    computed: {
      ...mapState({
        client: state => state.clients.client
      }),
      isHomePage() {
          return this.$route.path === '/'
      },
    },
    created(){
      console.log(this.client)
    },
    updated(){
      console.log(this.client)
    }
}
</script>