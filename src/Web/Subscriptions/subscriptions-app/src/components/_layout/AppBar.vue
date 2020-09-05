<template>
    <div>
        <v-app-bar 
        app
        clipped-right
        clipped-left
        v-if="client.loading">
            <v-toolbar-title
                class="ml-0 pl-md-4 pl-2"
            >
                <v-btn
                    icon
                    large
                    class="ml-0"
                    @click="onBrandClick"
                >
                    <v-avatar
                    size="2.7rem"
                    item
                    >
                    <v-skeleton-loader
                    type="avatar"
                    ></v-skeleton-loader>
                    </v-avatar>
                </v-btn>
            </v-toolbar-title>
        </v-app-bar>
        <v-app-bar
        v-else-if="client.success"
        app
        :color="client.data.navColor"
        :dark="client.data.navColor === 'black'"
        clipped-right
        clipped-left
        >
            <v-app-bar-nav-icon @click.stop="drawerLeft = !drawerLeft"></v-app-bar-nav-icon>
            
            <v-btn
                icon
                large
                class="ml-0"
                @click="onBrandClick"
            >
                <v-avatar
                size="2.7rem"
                item
                >
                <v-skeleton-loader
                v-if="client.loading"
                type="avatar"
                ></v-skeleton-loader>
                <v-img
                v-else-if="client.success"
                    :src="client.data.avatarUrl"
                    :alt="client.data.displayName"
                ></v-img>
                </v-avatar>
            </v-btn>
            <v-toolbar-title
                v-if="client.success"
                class="ml-0 pl-md-4 pl-2 text-uppercase"
            >
            {{client.data.displayName}}
            </v-toolbar-title>
            <v-spacer></v-spacer>

            <v-btn text :href="client.data.signInUrl">
                Login
            </v-btn>
            <v-btn text :href="client.data.signUpUrl">
                Join
            </v-btn>

            <!-- <v-btn icon @click.stop="drawerRight = !drawerRight">
                <v-icon>mdi-apps</v-icon>
            </v-btn> -->
        </v-app-bar>

        <v-navigation-drawer
        v-model="drawerLeft"
        clipped
        app
        left
        >
        <v-list dense>
            <template v-for="item in items">
            <v-row
                v-if="item.heading"
                :key="item.heading"
                align="center"
            >
                <v-col cols="6">
                <v-subheader v-if="item.heading">
                    {{ item.heading }}
                </v-subheader>
                </v-col>
                <v-col
                cols="6"
                class="text-center"
                >
                <a
                    href="#!"
                    class="body-2 black--text"
                >EDIT</a>
                </v-col>
            </v-row>
            <v-list-group
                v-else-if="item.children"
                :key="item.text"
                v-model="item.model"
                :prepend-icon="item.model ? item.icon : item['icon-alt']"
                append-icon=""
            >
                <template v-slot:activator>
                <v-list-item-content>
                    <v-list-item-title>
                    {{ item.text }}
                    </v-list-item-title>
                </v-list-item-content>
                </template>
                <v-list-item
                v-for="(child, i) in item.children"
                :key="i"
                link
                :to="child.to"
                :href="child.href"
                :target="child.href ? '_blank' : ''" 
                :rel="child.href ? 'noopener noreferrer' : ''">
                
                <v-list-item-action v-if="child.icon">
                    <v-icon>{{ child.icon }}</v-icon>
                </v-list-item-action>
                <v-list-item-content>
                    <v-list-item-title>
                    {{ child.text }}
                    </v-list-item-title>
                </v-list-item-content>
                </v-list-item>
            </v-list-group>
            <v-list-item
                v-else
                :key="item.text"
                link
                :to="item.to"
            >
                <v-list-item-action>
                <v-icon>{{ item.icon }}</v-icon>
                </v-list-item-action>
                <v-list-item-content>
                <v-list-item-title>
                    {{ item.text }}
                </v-list-item-title>
                </v-list-item-content>
            </v-list-item>
            </template>
        </v-list>
        </v-navigation-drawer>
    </div>
</template>

<script>
import { mapState } from 'vuex'

  export default {
    data: () => ({
      right: false,
      left: false,
      items: [
        { icon: 'mdi-home-variant', text: 'Home', to: '/' },
        { icon: 'mdi-cash-usd-outline', text: 'Pricing', to: '/pricing' },
        { icon: 'mdi-alert', text: 'Disclaimer', to: '/disclaimer' }
      ]
    }),
    computed: {
        ...mapState({
            client: state => state.clients.client
        }),
        drawerLeft: {
            get: function () {
                return this.left
            },
            set: function (val) {
                this.left = val
            }
        },
        isHomePage() {
            return this.$route.path === '/'
        }
    },
    created () {
      this.$store.dispatch('clients/getClient')
    },
    methods: {
        onBrandClick(){
            if(this.$route.fullPath === '/'){
                this.$vuetify.goTo('body', { duration: 300, easing: 'easeInCubic' })
            }
            else{
                this.$router.push({ path: '/' })
            }
        }
    }
  }
</script>