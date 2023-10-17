<template>
<div>
<!-- <vue-web-cam>

</vue-web-cam> -->
<div id="app">
        <div><video ref="video" id="video" width="640" height="480" autoplay></video></div>
        <div><button id="snap" v-on:click="capture()">Snap Photo</button></div>
        <canvas ref="canvas" id="canvas" width="640" height="480"></canvas>
        <ul id="ejemplo">
            <li v-for="capture in captures">
                <!-- <img v-bind:src="capture.url" height="50" /> -->
            </li>
        </ul>
    </div>
</div>
</template>
<script>
//import WebCam from "../../src";

import Vue from 'vue';
import { WebCam } from "vue-web-cam";
 Vue.use(WebCam);
/* export default{
    components: {
        'vue-web-cam': WebCam
    }
} */
export default {
        name: 'app',
        data() {
            return {
                video: {},
                canvas: {},
                captures: []
            }
        },
        mounted() {
            this.video = this.$refs.video;
            if(navigator.mediaDevices && navigator.mediaDevices.getUserMedia) {
                navigator.mediaDevices.getUserMedia({ video: true }).then(stream => {
                    this.video.src = window.URL.createObjectURL(stream);
                    this.video.play();
                });
            }
        },
        methods: {
            capture() {
                this.canvas = this.$refs.canvas;
                var context = this.canvas.getContext("2d").drawImage(this.video, 0, 0, 640, 480);
                var capture={
                    url:canvas.toDataURL("image/png")
                };
                this.captures.push(capture);
            }
        }
    }
</script>
