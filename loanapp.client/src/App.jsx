import { useEffect, useState } from 'react';
import './App.css';

function App() {


    const [age, setAge] = useState('');
    const [loanAmount, setLoanAmount] = useState('');
    const [loanPeriod, setLoanPeriod] = useState('');
    const [message,setMessage] = useState('');
    const [alertType,setAlertType] = useState('');

    const handleAgeChange = (event) => {
        setAge(event.target.value);
    };

    const handleLoanAmountChange = (event) => {
        setLoanAmount(event.target.value);
    };

    const handleLoanPeriodChange = (event) => {
        setLoanPeriod(event.target.value);
    };

    const handleLoanSuggestion = (event) => {
        event.preventDefault();
        getLoanSuggestion();
    };

    return (
        <div className="container mt-4">
          <form onSubmit={handleLoanSuggestion}>
            <div className="form-group">
              <label>Age:</label>
              <input
                type="number"
                className="form-control"
                value={age}
                onChange={handleAgeChange}
                min={1}
                max={150}
                required
              />
            </div>
            <div className="form-group">
              <label>Loan Amount:</label>
              <input
                type="number"
                className="form-control"
                value={loanAmount}
                min={1}
                onChange={handleLoanAmountChange}
                required
              />
            </div>
            <div className="form-group">
              <label>Loan Period:</label>
              <input
                type="number"
                className="form-control"
                value={loanPeriod}
                onChange={handleLoanPeriodChange}
                min={12}
                required
              />
            </div>
            <button type="submit" className="btn btn-primary mt-5 mb-3">
              Get Loan Suggestion
            </button>
          </form>
    
          <div className={alertType} role="alert" >
            {message}
          </div>
        </div>
      );
    
    async function getLoanSuggestion() {
        const response = await fetch('loan/getLoanSuggestion',{
            method: 'POST',
            headers: {
              'Content-Type': 'application/json',
            },
            body: JSON.stringify({
                Age: age,
                Amount: loanAmount,
                LoanPeriodInMonths: loanPeriod
            })});

        if(response.ok){
            const data = await response.json();
            if(data.success)
            {
                setAlertType('alert alert-success');
                setMessage(`Total amount to pay: ${data.totalAmountToPay}`);
            }
            else{
                setAlertType('alert alert-danger');
                setMessage(data.message);
            }
        } else {
            setAlertType('alert alert-danger');
            setMessage('Ooops something wrong with the server. Please try again later'); // 
        }
    }
}

export default App;