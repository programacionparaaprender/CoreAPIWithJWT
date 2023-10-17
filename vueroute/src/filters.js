
import Vue from 'vue';

Vue.filter('uppercase',(value)=>{
    value = String(value)
    return value.toUpperCase();
});
Vue.filter('lowercase',(value)=>{
    value = String(value)
    return value.toLowerCase();
});
Vue.filter('dollar',(value)=>{
    return '$'+value;
});

Vue.filter('readmore',(text, length, suffix)=>{
    text = String(text);
    return text.substring(0, length) + suffix;
});