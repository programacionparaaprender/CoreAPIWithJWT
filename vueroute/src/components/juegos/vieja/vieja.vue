<template>
<div>
  <div class="card card-default card-demo">
    <div class="card-body">
      <div className="game">
            <div className="game-board">
              <div style="float: left;width: 300px;display:block;">
              <div style="float:left;width:100%;" className="board-row">
              <div style="float: left;width: 33.33%;">
                  <button 
                  @click="handleClick(0)"
                  style="margin:0; paddingLeft: 0; listStyle: none; width:100px; height:100px;" className="square">
                    {{mostrarSquares[0]}}
                  </button>
              </div>
              <div style="float: left;width: 33.33%;">
                  <button 
                  @click="handleClick(1)"
                  style="margin:0; paddingLeft: 0; listStyle: none; width:100px; height:100px;" className="square">
                    {{mostrarSquares[1]}}
                  </button>
              </div>
              <div style="float: left;width: 33.33%;">
                  <button 
                  @click="handleClick(2)"
                  style="margin:0; paddingLeft: 0; listStyle: none; width:100px; height:100px;" className="square">
                    {{mostrarSquares[2]}}
                  </button>
              </div>
              <div style="float:left;width:100%;" className="board-row">
              <div style="float: left;width: 33.33%;">
                  <button 
                  @click="handleClick(3)"
                  style="margin:0; paddingLeft: 0; listStyle: none; width:100px; height:100px;" className="square">
                    {{mostrarSquares[3]}}
                  </button>
              </div>
              <div style="float: left;width: 33.33%;">
                  <button 
                  @click="handleClick(4)"
                  style="margin:0; paddingLeft: 0; listStyle: none; width:100px; height:100px;" className="square">
                    {{mostrarSquares[4]}}
                  </button>
              </div>
              <div style="float: left;width: 33.33%;">
                  <button 
                  @click="handleClick(5)"
                  style="margin:0; paddingLeft: 0; listStyle: none; width:100px; height:100px;" className="square">
                    {{mostrarSquares[5]}}
                  </button>
              </div>
              </div>
              <div style="float:left;width:100%;" className="board-row">
              <div style="float: left;width: 33.33%;">
                  <button 
                  @click="handleClick(6)"
                  style="margin:0; paddingLeft: 0; listStyle: none; width:100px; height:100px;" className="square">
                    {{mostrarSquares[6]}}
                  </button>
              </div>
              <div style="float: left;width: 33.33%;">
                  <button 
                  @click="handleClick(7)"
                  style="margin:0; paddingLeft: 0; listStyle: none; width:100px; height:100px;" className="square">
                    {{mostrarSquares[7]}}
                  </button>
              </div>
              <div style="float: left;width: 33.33%;">
                  <button 
                  @click="handleClick(8)"
                  style="margin:0; paddingLeft: 0; listStyle: none; width:100px; height:100px;" className="square">
                    {{mostrarSquares[8]}}
                  </button>
              </div>
              </div>
              </div>
              </div>
            </div>
            <div style="float:left;width:100%;" className="form-control game-info">
              <div style="float:left;width:100%;">
                  {{quiengano}}      
              </div>     
              <div style="float:left;width:100%;">
                <ol>
                  <li v-bind:key="index" v-for="(item, index) in state.history">
                    <button 
                      class="btn btn-secondary"
                      @click="jumpTo(index)">
                      Go to move #{{index}}
                    </button>
                  </li>
                  </ol>    
              </div>   
            </div>
      </div>
    </div>

  </div>
    
</div>
</template>
<script>

//import square from './square.vue'

export default{
    components:{
        //'Square':square
    },
	data(){
		return{
      
      state:{
        hayganador:false,
        contador:0,
        squares: [null,null,null,null,null,null,null,null,null],
        history: [{
          squares: Array(9).fill(null),
        }],
        stepNumber: 0,
        xIsNext: true,
      } 
		}
    },
    mounted(){
      //setTimeout(this.$forceUpdate(), 500)
    },
    computed:{
      /* squares:{
        get: function () {
          return this.squaresTemp
        },
        // setter
        set: function (newValue) {
          this.squaresTemp = newValue
        }
      } */
      /* squares(){
        return this.$store.state.squares;
      } */
      quiengano(){
        //const squares = this.state.history[this.state.stepNumber];
        if (this.state.hayganador) {
          return 'Winner: ' + (this.state.xIsNext ? 'O' : 'X');
        } 
        else {
          return 'Next player: ' + (this.state.xIsNext ? 'X' : 'O');
        }
      },
      mostrarSquares()
      { 
        const current = this.state.history[this.state.stepNumber];
        return current.squares;
      }
    },
    methods:{
      
      handleClick(i) {
        if(this.state.hayganador){
          return;
        }
        //console.log(i);
        
        //console.log(this.squares[i])
        const history = this.state.history.slice(0, this.state.stepNumber + 1);
        const current = history[history.length - 1];
        const squares = current.squares.slice();
        squares[i] = this.state.xIsNext ? 'X' : 'O';
        //this.state.history.push({squares: squares});
        //this.state.stepNumber++;

        this.state.history = history.concat([{
          squares: squares
        }]),
        this.state.stepNumber = history.length;
        this.state.xIsNext = !this.state.xIsNext;

        console.log(squares);

        if (this.calculateWinner(squares) ) {
          this.state.hayganador = true;
        }
        
   
        /* this.$nextTick(() => {
          // Add the component back in
          this.state.history[this.state.contador].squares[i] = this.state.xIsNext ? 'X' : 'O';
          this.state.xIsNext = !this.state.xIsNext;
          this.$store.dispatch('SETSQUARES',
         {
          squares: this.state.squares}
          );
        }); */

     


      /* this.setState({
        history: history.concat([{
          squares: squares
        }]),
        stepNumber: history.length,
        xIsNext: !this.state.xIsNext,
      }); */
      
    },
    jumpTo(step) {
      this.state.stepNumber = step;
        this.state.xIsNext = (step % 2) === 0;
    },
      calculateWinner(squares) {
        const lines = [
          [0, 1, 2],
          [3, 4, 5],
          [6, 7, 8],
          [0, 3, 6],
          [1, 4, 7],
          [2, 5, 8],
          [0, 4, 8],
          [2, 4, 6],
        ];
        for (let i = 0; i < lines.length; i++) {
          const [a, b, c] = lines[i];
          if (squares[a] && squares[a] === squares[b] && squares[a] === squares[c]) {
            return squares[a];
          }
        }
        return null;
      }
    }

}
</script>