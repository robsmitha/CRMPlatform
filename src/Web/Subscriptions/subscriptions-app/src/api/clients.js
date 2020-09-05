//import { get } from './api'

export function b2cLoginUrl(appConfig) {
    return `https://${appConfig.directory}.b2clogin.com/${appConfig.directory}.onmicrosoft.com/oauth2/v2.0/authorize?p=${appConfig.signin_userflow}&client_id=${appConfig.client_id}&nonce=${appConfig.nonce}&redirect_uri=${appConfig.redirect_uri}&scope=${appConfig.scope}&response_type=${appConfig.response_type}&prompt=${appConfig.prompt}&response_mode=${appConfig.response_mode}`
}
//TODO: Call merchants service
const clients = [
    {
        id: 1,
        avatarUrl: 'https://pbs.twimg.com/profile_images/1261498186721488896/cRDBIISx_400x400.jpg',
        displayName: 'Limitless Trading',
        fullName: 'Limitless Trading, LLC',
        tagLine: 'Trade Without Limits',
        callToAction: 'Join our growing trading community now! Only $89/month',
        missionStatement: 'Limitless Trading, LLC is a cost effective platform that provides day traders and swing traders a simple, easy to understand trading strategy, while encouraging members to participate in our online community. This mission is rooted in our strategies, belief that honesty, integrity and transparency has the power to make each member’s life richer and more fulfilling while empowering people to believe in themselves. We believe education should not cost a fortune and that everybody should be able to learn the markets to better their lives and the lives of those around them.',
        headerImage: 'https://smitha-cdn.s3.us-east-2.amazonaws.com/Content/images/md/bg-007.jpg',
        disclaimer: `Limitless Trading, LLC and/or its partners offer general trading information and opinions that do not take into consideration factors such as your trading experience, personal objectives and goals, financial means, or risk tolerance.  Decisions to buy, sell, hold or trade in securities and other investments involve risk and are best made based on the advice of qualified financial professionals. The practice of trading options involves very high risks and can cause you to lose substantial sums of money.  Past performance is no indication of future results.
        Limitless Trading, LLC, and its partners are not investment advisors or securities brokers. All information provided is strictly opinions for informational and educational purposes. We may or may not execute trades; we only offer information.
        By signing up for the Private Twitter and Discord Chat account, you are agreeing to these terms and conditions, and you agree that Limitless Trading, LLC and its partners are not responsible for any losses that may occur for any reason as a result of Limitless Trading, LLC and its partner’s trade information and option plays on Twitter, website, or chat room communication and Q&A. None of the information provided is a recommendation for an investment that is suitable for you.
        Limitless Trading, LLC. and its partners are not liable for any losses or damage as a result of following the information provided on and from the Private Twitter Feed, Live Stream, or Tradewithoutlimits.com`,
        features: [
            { color: 'black', icon: 'mdi-lightbulb-on-outline', title: 'Trade Ideas', text: 'Members will receive full Live Trades Alerts including position sizes, entries, exits, strike prices and risk levels.' },
            { color: 'black', icon: 'mdi-playlist-star', title: 'Nightly Watchlists', text: 'Detailed nightly watchlist focusing on the stocks that have the highest probability of success.' },
            { color: 'black', icon: 'mdi-file-excel', title: 'Weekly trading logs', text: 'Before the market opens, we go over the top watches for that day and setup a detailed trade plan.' }
        ],
        subscriptions: [
            { image: 'https://pbs.twimg.com/profile_banners/1246635566835183617/1589584331/600x200', title: 'All Access', text: 'Members will gain access to private twitter and chat room.' }
        ],
        navColor: 'black',
        signInUrl: b2cLoginUrl({
            directory: process.env.VUE_APP_B2C_DIRECTORY,
            signin_userflow: process.env.VUE_APP_B2C_SIGN_IN_POLICY,
            client_id: process.env.VUE_APP_B2C_CLIENT_ID,
            redirect_uri: process.env.VUE_APP_B2C_REDIRECT_URL,
            nonce: process.env.VUE_APP_B2C_NONCE,
            scope: process.env.VUE_APP_B2C_SCOPE,
            response_type: process.env.VUE_APP_B2C_RESPONSE_TYPE,
            prompt: process.env.VUE_APP_B2C_PROMPT,
            response_mode: process.env.VUE_APP_B2C_RESPONSE_MODE
        }),
        signUpUrl: b2cLoginUrl({
            directory: process.env.VUE_APP_B2C_DIRECTORY,
            signin_userflow: process.env.VUE_APP_B2C_SIGN_UP_POLICY,
            client_id: process.env.VUE_APP_B2C_CLIENT_ID,
            redirect_uri: process.env.VUE_APP_B2C_REDIRECT_URL,
            nonce: process.env.VUE_APP_B2C_NONCE,
            scope: process.env.VUE_APP_B2C_SCOPE,
            response_type: process.env.VUE_APP_B2C_RESPONSE_TYPE,
            prompt: process.env.VUE_APP_B2C_PROMPT,
            response_mode: process.env.VUE_APP_B2C_RESPONSE_MODE
        }),
        socialMedia: [
            {
                icon: 'mdi-twitter',
                color: 'blue',
                href: 'https://twitter.com/LimitlessT1',
                text: 'Twitter'
            }
        ]
    }
]

export default {
    getClient
}

async function getClient(id){
    return clients.find(x => x.id === id)
}