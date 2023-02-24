<template>
    <div>
        <h1>{{ title }}</h1>
        <table>
            <tr>
                <th>Number</th>
                <th>Date</th>
            </tr>
            <tr v-for="report in reports" :key="report.id">
                <td>
                    {{ report.number }}
                </td>
                <td>
                    {{ formatDate(report.createOn) }}
                </td>
            </tr>
        </table>
    </div>
</template>

<script lang="js">
    import axios from 'axios'

    export default {
        name: 'ReportView',
        components: {},
        data() {
            return {
                title: 'Report page',
                reports: null
            };
        },
        created() {
            this.getData();
        },
        methods: {
            async getData() {
                try {
                    const response = await axios.get('https://localhost:5002/api/report');
                    this.reports = response.data;
                    console.log(response);
                } catch (e) {
                    alert('Error')
                }
            },
            formatDate(dateString) {
                const options = { day: '2-digit', month: '2-digit', year: 'numeric' };
                const date = new Date(dateString);
                return date.toLocaleDateString('ru-RU', options);
            }
        }
    }
</script>

<style>

</style>