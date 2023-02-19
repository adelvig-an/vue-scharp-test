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
                    {{ report.date}}
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
                reports: []
            };
        },
        
        methods: {
            async getData() {
                const response = await axios.get('https://localhost:5002/api/report');
                this.reports = response;
            }
        }
    }
</script>

<style>

</style>