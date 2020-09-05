<template>
  <div>
    <v-sheet v-if="client.loading" height="500px">
        <v-container
          fluid
          fill-height
          >
          <v-row
          align="center"
          justify="center">
            <v-col class="text-center">
              <div class="mb-7">
                <v-skeleton-loader
                type="text"
                class="mx-auto mb-2"
                width="25rem"
                ></v-skeleton-loader>
                <v-skeleton-loader
                type="text"
                class="mx-auto"
                width="15rem"
                height="3rem"
                ></v-skeleton-loader>
              </div>
              <v-btn x-large disabled class="mt-7" tile>Loading</v-btn>
            </v-col>
          </v-row>
        </v-container>
    </v-sheet>
    <v-parallax v-if="client.success" :src="client.data.headerImage">
        <v-container
          fluid
          >
          <v-row>
            <v-col class="text-center">
               <span class="text-lg-h3 text-h2 text-uppercase">
                {{client.data.tagLine}}
              </span>
              <p class="subtitle-2">
                {{client.data.displayName}}
              </p>
            </v-col>
          </v-row>
        </v-container>
         <div class="text-center">
          <v-btn color="black" dark x-large tile>
            Join Now
          </v-btn>
        </div>
      </v-parallax>
      <v-sheet color="grey lighten-3 py-7 text-center" id="callToAction">
        <v-skeleton-loader
        width="12rem"
        v-if="client.loading"
        type="text"
        class="mx-auto"
        ></v-skeleton-loader>
        <span v-else-if="client.success" class="text-uppercase text-h5 d-block">
          {{client.data.callToAction}}
        </span>
      </v-sheet>
      <v-container class="py-7">
        <div class="mb-2">
          <span class="text-h4">
            Our Mission
          </span>
          <p class="subtitle-2">
            Join us today
          </p>
        </div>
        <v-skeleton-loader v-if="client.loading"
          type="paragraph"
        ></v-skeleton-loader>
        <p v-else-if="client.success" class="text-body-1">
          {{client.data.missionStatement}}
        </p>
      </v-container>
      
      <v-container class="py-7">
        <span class="text-h4">
          Features
        </span>
        <p class="subtitle-2">
          What makes us special
        </p>
        <v-row v-if="client.loading">
          <v-col md="4" sm="6" xs="12"
              v-for="i in 3"
              :key="i">
            <v-skeleton-loader
              type="article"
            ></v-skeleton-loader>
          </v-col>
        </v-row>
        <v-row v-else-if="client.success">
          <v-col md="4" sm="6" xs="12"
              v-for="i in client.data.features"
              :key="i.title"
            >
            <v-card
              height="100%"
              class="py-4"
            >
            <v-list-item>
              <v-list-item-content>
                <v-list-item-title class="headline mb-1">{{i.title}}</v-list-item-title>
              </v-list-item-content>

              <v-list-item-avatar
                tile
              >
              <v-icon 
                :color="`${i.color}`">
                {{i.icon}}
                </v-icon>
              </v-list-item-avatar>
            </v-list-item>
            <v-card-text>{{i.text}}</v-card-text>
            </v-card>
          </v-col>
        </v-row>
      </v-container>
      
      <v-container class="py-7">
        <span class="text-h4">
          Membership
        </span>
        <p class="subtitle-2">
          Thanks for your interest
        </p>
        <v-row v-if="client.loading">
          <v-col md="4" sm="6" xs="12"
              v-for="i in 3"
              :key="i">
            <v-skeleton-loader
              type="card"
            ></v-skeleton-loader>
          </v-col>
        </v-row>
        <v-row v-else-if="client.success">
          <v-col md="4" sm="6" xs="12"
              v-for="i in client.data.subscriptions"
              :key="i.title"
            >
          <v-card
            class="mx-auto"
            height="100%"
          >
            <v-img
              class="white--text align-end"
              height="200px"
              :src="i.image"
            >
            </v-img>
              <v-card-title>{{i.title}}</v-card-title>
            <v-card-text>
              {{i.text}}
            </v-card-text>
          </v-card>
          </v-col>
        </v-row>
      </v-container>
  </div>
</template>

<script>
import { mapState } from 'vuex'
export default {
  computed: {
    ...mapState({
        client: state => state.clients.client
      }),
  },
  created () {
    this.$store.dispatch('clients/getClient')
  },
}
</script>
